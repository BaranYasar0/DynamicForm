namespace DynamicForm.MVCWebApp.Models.ViewModels.Forms
{
    public class GetFormListViewModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int CreatedBy { get; set; }
        public ICollection<GetFieldListDto>? GetFieldListDto { get; set; }
    }

    public class GetFieldListDto
    {
        public bool Required { get; set; } = true;
        public string Name { get; set; }
        public string DataType { get; set; } = "STRING";
    }
}
