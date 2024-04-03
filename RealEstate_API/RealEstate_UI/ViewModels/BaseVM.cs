using System;
namespace RealEstate_UI.ViewModels
{
	public class BaseVM
	{
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public BaseVM()
		{
		}
	}
}

