using MD.PersianDateTime.Standard;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Talakado.Application.Discounts.AddNewDiscountService;

namespace Talakado.AdminPanel.Binders
{
    public class DiscountEntityBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            string FieldName = bindingContext.FieldName;

            AddNewDiscountDto discountDto = new AddNewDiscountDto()
            {
                CouponCode = bindingContext.ValueProvider.GetValue($"{FieldName}.{nameof(discountDto.CouponCode)}").Values.ToString(),
                Name = bindingContext.ValueProvider.GetValue($"{FieldName}.{nameof(discountDto.Name)}").Values.ToString(),
                DiscountAmount = int.Parse(bindingContext.ValueProvider.GetValue($"{FieldName}.{nameof(discountDto.DiscountAmount)}").Values.ToString()),
                DiscountLimitationId = int.Parse(bindingContext.ValueProvider.GetValue($"{FieldName}.{nameof(discountDto.DiscountLimitationId)}").Values.ToString()),
                DiscountTypeId = int.Parse(bindingContext.ValueProvider.GetValue($"{FieldName}.{nameof(discountDto.DiscountTypeId)}").Values.ToString()),
                LimitationTimes = int.Parse(bindingContext.ValueProvider.GetValue($"{FieldName}.{nameof(discountDto.LimitationTimes)}").Values.ToString()),
                DiscountPercentage = int.Parse(bindingContext.ValueProvider.GetValue($"{FieldName}.{nameof(discountDto.DiscountPercentage)}").Values.ToString()),
                UserPercentage = bool.Parse((bindingContext.ValueProvider.GetValue($"{FieldName}.{nameof(discountDto.UserPercentage)}").FirstValue)??"false".ToString()),
                RequiredCouponCode = bool.Parse(bindingContext.ValueProvider.GetValue($"{FieldName}.{nameof(discountDto.RequiredCouponCode)}").FirstValue ?? "false".ToString()),
                StartDate = PersianDateTime.Parse(bindingContext.ValueProvider.GetValue($"{FieldName}.{nameof(discountDto.StartDate)}").Values.ToString()),
                EndDate = PersianDateTime.Parse(bindingContext.ValueProvider.GetValue($"{FieldName}.{nameof(discountDto.EndDate)}").Values.ToString())
            };

            var appliedToCatalogItem = bindingContext.ValueProvider.GetValue("model.AppliedToCatalogItem");
            if (!string.IsNullOrEmpty(appliedToCatalogItem.Values))
            {
                discountDto.AppliedToCatalogItem = bindingContext.ValueProvider.GetValue($"{FieldName}.{nameof(discountDto.AppliedToCatalogItem)}").Values.ToString().Split(',').Select(x=> Int32.Parse(x)).ToList();
            }

            bindingContext.Result = ModelBindingResult.Success(discountDto);
            return Task.CompletedTask;
        }
    }
}
