package c8y.example;

import c8y.IsDevice;
import com.cumulocity.model.authentication.CumulocityCredentials;
import com.cumulocity.rest.representation.inventory.ManagedObjectRepresentation;
import com.cumulocity.sdk.client.Platform;
import com.cumulocity.sdk.client.PlatformImpl;
import com.cumulocity.sdk.client.inventory.InventoryApi;

public class App 
{
    public static void main( String[] args )
    {
        Platform platform = new PlatformImpl("https://vis3d.iot.cs.ut.ee", new CumulocityCredentials("andrei.voitenko96", "A01019aa"));
        InventoryApi inventory = platform.getInventoryApi();
        ManagedObjectRepresentation mo = new ManagedObjectRepresentation();
        mo.setName("New device");
        mo.set(new IsDevice());
        mo = inventory.create(mo);
        System.out.println("URL: " + mo.getSelf());
    }
}