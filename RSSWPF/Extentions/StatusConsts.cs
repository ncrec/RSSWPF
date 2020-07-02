using System;

namespace RSSWPF.Extentions
{
    public static class StatusConsts
    {
        public static readonly Guid SoldOut = new Guid("E1A84B1D-B821-4AFF-A718-E7E281E87880");
        public static readonly Guid Accepted = new Guid("E16D4198-720A-459E-8020-9F4150D9222D");
        public static readonly Guid ToTheWarehouse = new Guid("3C6BF8A3-5D41-43D6-AACB-B76D84E5881C");
        public static readonly Guid Created = new Guid("4f736a22-86ef-4b69-a443-18e2cea64a52");
        public const string SoldOutStr = "Продан";
        public const string AcceptedStr = "Принят";
        public const string ToTheWarehouseStr = "На склад";
        public const string All = "Все";
    }
}
