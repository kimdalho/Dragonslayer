public interface iEscape
{
    public void OnEscape();
}

public abstract class Base_Panel : UI_Base, iEscape
{
    public virtual void OnEscape()
    {
    
    }
}
