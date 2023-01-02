using System;

public static class CardEventsHandler
{
    public static event Action<CardParemeters> OnModificateHealth;
    public static event Action<CardParemeters> OnModificateMovement;
    public static event Action<CardParemeters> OnModificateSpawn;


    public static void InvokeEvent(CardParemeters cardParemeters) {
        switch (cardParemeters.typeImplant) {
            case TypeImplant.Health:
                OnModificateHealth?.Invoke(cardParemeters);
                break;
            case TypeImplant.Movement:
                OnModificateMovement?.Invoke(cardParemeters);
                break;
            case TypeImplant.Spawn:
                OnModificateSpawn?.Invoke(cardParemeters);
                break;
        }   
    }
}