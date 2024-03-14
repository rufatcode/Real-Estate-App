using System;
namespace RealEstate_API.Dtos
{
	public abstract class BaseDto
	{
		public int Id { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedAt { get; set; }
		public Nullable<DateTime> DeletedAt { get; set; }
		public Nullable<DateTime> UpdatedAt { get; set; }
        public BaseDto()
		{
		}
	}
}

