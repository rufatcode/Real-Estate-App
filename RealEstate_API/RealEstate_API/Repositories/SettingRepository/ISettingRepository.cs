using System;
using RealEstate_API.Dtos.SettingDtos;

namespace RealEstate_API.Repositories.SettingRepository
{
	public interface ISettingRepository
	{
		Task Create(CreateSettingDto createSettingDto);
		Task<int> Update(UpdateSettingDto updateSettingDto);
		Task<int> Delete(int id);
		Task<List<ResoultSettingDto>> Get();
		Task<ResoultSettingDto> Get(int id);
    }
}

