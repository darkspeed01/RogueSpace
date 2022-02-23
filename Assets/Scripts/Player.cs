using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    
    struct Character
    {
        public string characterName;
        public string shipName;
        public string galaxyName;
        public string subSystemInstalled;
        public string componentInstalled;
        public string deployableInstalled;
        public int level;

        public Character(string character, string ship, string galaxy, string subSystem, string comp, string deploy)
        {
            this.characterName = character;
            this.shipName = ship;
            this.galaxyName = galaxy;
            this.subSystemInstalled = subSystem;
            this.componentInstalled = comp;
            this.deployableInstalled = deploy;
            this.level = 1;
        }
    }
    
    public void CreateCharacter()
    {

        this.CurrentCharacter = new Character(nameInputField.GetComponent<InputField>().text, shipType.GetComponent<Dropdown>().captionText.text, galaxy.GetComponent<Dropdown>().captionText.text,
        subSystem.GetComponent<Dropdown>().captionText.text, componentName.GetComponent<Dropdown>().captionText.text, deployable.GetComponent<Dropdown>().captionText.text);

        Debug.Log("Character Name: " + CurrentCharacter.characterName);
        Debug.Log("Ship Name: " + CurrentCharacter.shipName);
        Debug.Log("Galaxy: " + CurrentCharacter.galaxyName);
        Debug.Log("Sub-System: " + CurrentCharacter.subSystemInstalled);
        Debug.Log("Component: " + CurrentCharacter.componentInstalled);
        Debug.Log("Deployable: " + CurrentCharacter.deployableInstalled);
        Debug.Log("Level: " + CurrentCharacter.level);

    }

    //public GameObject shipContainer;
    //public List<ShipType> unlocked_ships;
    //public List<ShipType> savedShips;
    private Character currentCharacter;

    public GameObject nameInputField, shipType, galaxy;
    public GameObject subSystem, componentName, deployable;
    [SerializeField] float maxHealth = 100f;
    float currentHealth = 100f;

    private Character CurrentCharacter
    {
        get
        {
            return currentCharacter;
        }

        set
        {
            currentCharacter = value;
        }
    }

    void Awake()
    {

        DontDestroyOnLoad(this);
    }

    public float healthAsPercentage
    {
        get
        {
            return currentHealth / maxHealth;
        }
    }

}