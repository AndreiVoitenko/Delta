package c8y.example.hello_agent;

import com.cumulocity.model.authentication.CumulocityCredentials;
import com.cumulocity.sdk.client.ClientConfiguration;
import com.cumulocity.sdk.client.PlatformParameters;
import com.cumulocity.sdk.client.notification.Subscription;
import com.cumulocity.sdk.client.notification.SubscriptionListener;

import java.io.IOException;


public class ExampleStreamReader {


    static String tenant = "vis3d";
    static String platform_url = "https://vis3d.iot.cs.ut.ee";
    static String apikey = "";
    public static String username = "andrei.voitenko96";
    public static String password = "AndreiVoitenko";

    public static void main(String[] args) throws InterruptedException, IOException {


        CumulocityCredentials credentials = new CumulocityCredentials(username, password);
        PlatformParameters pp = new PlatformParameters(platform_url, credentials, new ClientConfiguration());


        final StreamReader sr = new StreamReader(pp);

        sr.subscribe("/events/10225", new SubscriptionListener<String, Object>() {

            public void onNotification(Subscription<String> stringSubscription, Object o) {
                System.out.println(o);
            }


            public void onError(Subscription<String> stringSubscription, Throwable throwable) {
                throwable.printStackTrace();
            }
        });

        Runtime.getRuntime().addShutdownHook(new Thread() {
            @Override
            public void run() {
                System.out.println("disconnecting");
                sr.disconnect();
            }
        });

        while (true) {
            Thread.sleep(1000);
        }

    }

}