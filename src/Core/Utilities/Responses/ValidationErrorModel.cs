namespace Core.Utilities.Responses
{
    public class ValidationErrorResponseModel
    {
        public List<ValidationErrorModel>? Errors {get;set;}

        public ValidationErrorResponseModel(List<ValidationErrorModel>? errors)
        {
            this.Errors = errors;
        }
    }
    public class ValidationErrorModel
    {
        public ValidationErrorModel(string propertyName,string description) 
        {
            this.PropertyName = propertyName;
            this.Description = description;
   
        }
        public string PropertyName { get; set; }
        public string Description { get; set; }
    }
}