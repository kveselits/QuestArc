using QuestArc.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace QuestArc.TemplateSelectors
{
    public class CharacterDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CharacterTemplate { get; set; }

        public DataTemplate ArcTemplate { get; set; }

        public DataTemplate QuestTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            return GetTemplate(item) ?? base.SelectTemplateCore(item);
        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            return GetTemplate(item) ?? base.SelectTemplateCore(item, container);
        }

        private DataTemplate GetTemplate(object item)
        {
            switch (item)
            {
                case Character character:
                    return CharacterTemplate;
                case Arc arc:
                    return ArcTemplate;
                case Quest quest:
                    return QuestTemplate;
            }

            return null;
        }
    }
}
