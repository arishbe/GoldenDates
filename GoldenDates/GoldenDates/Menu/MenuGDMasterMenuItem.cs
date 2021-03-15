using System;

namespace GoldenDates.Menu
{

    public class MenuGDMasterMenuItem
    {
        public MenuGDMasterMenuItem()
        {
            TargetType = typeof(MenuGDMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}