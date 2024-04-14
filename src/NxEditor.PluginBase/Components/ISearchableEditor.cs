namespace NxEditor.PluginBase.Components;

public interface ISearchableEditor : IEditor
{
    int Find(SearchContext context);
}
