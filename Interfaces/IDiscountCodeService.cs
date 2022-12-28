using PSP.Enums;
using PSP.Models;

namespace PSP.Interfaces
{
    /*
    DISCLAMER:
        This endpoint is designed extremely poorly.
        * It has no way to get existing codes
        * It does not allow to delete codes
        * !!!It edits codes by refering to them by only one of the two primary keys that are declared in USM document
        It will not function as intended originaly in the USM document
    */
    public interface IDiscountCodeService
    {
        DiscountCode Create(DiscountCode discountCode);
        DiscountCode Update(string code, DiscountCode discountCode);
        DiscountCode UpdateStatus(string code, DiscountCodeStatus status);
    }
}
