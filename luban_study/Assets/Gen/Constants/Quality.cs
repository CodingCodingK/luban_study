//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cfg.Constants
{
    [System.Flags]
    public enum Quality
    {
        /// <summary>
        /// 最高品质
        /// </summary>
        Highest = 1,
        /// <summary>
        /// 暗金的
        /// </summary>
        Unique = 2,
        /// <summary>
        /// 亮金的
        /// </summary>
        Normal = 4,
        /// <summary>
        /// 附魔的
        /// </summary>
        Enchanted = 8,
        /// <summary>
        /// 暗金/附魔的
        /// </summary>
        EnchantedUnique = Enchanted|Unique,
        /// <summary>
        /// 亮金/附魔的
        /// </summary>
        EnchantedNormal = Enchanted|Normal,
    }
}