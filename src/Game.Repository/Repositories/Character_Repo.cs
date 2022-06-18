//namespace Game.Repository;
public class Character_Repo
{
    private readonly List<Character> _charRepo = new List<Character>();
    public bool AddCharacterToRecord(Character Char)
    {
        if(Char!=null)
        {
            _charRepo.Add(Char);
            return true;
        }
        return false;
    }    
    public List<Character> ViewAllCharacters()
    {
        return _charRepo;
    }
    public Character ViewCharacterByName(string name)
    {
        foreach(Character c in _charRepo)
        {
            if(c.Name == name)
            {
                return c;
            }
        }
        return null;
    }
    public bool RemoveCharacterByName(string name)
    {
        var Char = ViewCharacterByName(name);
        bool Success = _charRepo.Remove(Char);
        if(Success)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
