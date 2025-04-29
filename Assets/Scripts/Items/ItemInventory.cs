using System;
[Serializable]
public class ItemInventory
{
    public string itemId;
    public ItemProfileSO itemProfile;
    public int itemCount = 0;
    public int maxStack = 7;
    public int upgradeLevel = 0;

    public virtual ItemInventory Clone()
    {
        ItemInventory item = new()
        {
            itemId = ItemInventory.RandomID(),
            itemProfile = this.itemProfile,
            itemCount = this.itemCount,
            upgradeLevel = this.upgradeLevel
        };

        return item;
    }

    public static string RandomID(int length = 10)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        char[] stringChars = new char[length];
        Random random = new();

        for (int i = 0; i < length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        return new string(stringChars);
    }
}
