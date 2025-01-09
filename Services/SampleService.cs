using AutoMapper;
using NodeApl.API.Domain.DTOs;
using NodeApl.API.Domain.Entities;
using NodeApl.API.Domain.Interfaces;
using NodeApl.API.Domain.Responses;

namespace NodeApl.API.Services;

public class SampleService(ISampleRepository sampleRepository, IUserRepository userRepository, IMapper mapper) : ISampleService
{
    public async Task<IEnumerable<SampleDto>> GetByNodeIdAsync(int nodeId)
    {
        return await sampleRepository.GetSamplesByNodeIdAsync(nodeId);
    }

    public async Task<IEnumerable<SampleDto>> GetByNodeIdsAsync(IEnumerable<int> nodeIds)
    {
        return await sampleRepository.GetSamplesByNodeIdsAsync(nodeIds);
    }

    public async Task<SampleAddResponse> AddByLoginAsync(string login, SampleAddDto sampleAddDto)
    {
        var user = await userRepository.GetUserByLoginAsync(login);

        if (user == null)
        {
            return new SampleAddResponse{Success = false, Message = "Указанного пользователя не существует"};
        }

        var sample = mapper.Map<Sample>(sampleAddDto);
        sample.UserId = user.Id;
        
        try
        {
            var addedSample = await sampleRepository.AddAsync(sample);
            var result = await sampleRepository.SaveChangesAsync();
            var sampleDto = mapper.Map<SampleDto>(addedSample);
            
            if (result > 0)
            {
                return new SampleAddResponse{Success = true, Message = "Элемент выборки успешно добавлен.", SampleDto = sampleDto};
            }
            
            return new SampleAddResponse{Success = false, Message = "Ошибка при добавлении элемента выборки. Попробуйте позже."};
            
            
        }
        catch (Exception ex)
        {
            return new SampleAddResponse{Success = false, Message = "Ошибка при добавлении элемента выборки." };
        }
    }

    public async Task<SampleDeleteResponse> DeleteByIdsAsync(IEnumerable<int> ids)
    {
        var samples = await sampleRepository.GetSamplesByIdsAsync(ids);
        var listDeleted = new List<int>();
        var listFailed = new List<int>();
        foreach (var sample in samples)
        {
            sampleRepository.Delete(sample);
            var result = await sampleRepository.SaveChangesAsync();
            if (result > 0)
            {
                listDeleted.Add(sample.Id);
            }
            else
            {
                listFailed.Add(sample.Id);
            }
        }

        if (listDeleted.Count > 0)
        {
            return new SampleDeleteResponse {Success = true, Message = "Состояние после удаления элементов выборки.", DeletedIds = listDeleted, FailedIds = listFailed};
        } 
        
        return new SampleDeleteResponse {Success = false, Message = "Нет удаленных элементов.", DeletedIds = listDeleted, FailedIds = listFailed};
    }

    public async Task<SampleUpdateResponse> Update(string login, SampleUpdateDto sample)
    {
        var user = await userRepository.GetUserByLoginAsync(login);
        if (user == null)
        {
            return new SampleUpdateResponse { Success = false, Message = "Пользователя не существует." };
        }
        
        var existingSample = await sampleRepository.GetByIdAsync(sample.Id);
        if (existingSample == null)
        {
            return new SampleUpdateResponse { Success = false, Message = "Обновляемого элемента выборки не существует." };
        }
        
        existingSample.Name = sample.Name;
        existingSample.CreateDate = sample.CreateDate;
        existingSample.UserId = user.Id;

        try
        {
            sampleRepository.Update(existingSample);
            var result = await sampleRepository.SaveChangesAsync();
            if (result > 0)
            {
                return new SampleUpdateResponse { Success = true, Message = "Элемент выборки успешно обновлен." };
            }

            return new SampleUpdateResponse
                { Success = false, Message = "Ошибка при обновления элемента выборки. Попробуйте позже." };
        }
        catch (Exception ex)
        {
            return new SampleUpdateResponse { Success = false, Message = "Ошибка при обновления элемента выборки." };
        }
    }
}