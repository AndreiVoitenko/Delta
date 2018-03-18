package c8y.example.hello_agent;

import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;

public class send {
    public static void runJavaSocket() {
        System.out.println("Java Sockets Program has started.");
        int i = 0;

        try {
            DatagramSocket socket = new DatagramSocket();
            System.out.println("Sending the udp socket...");
// Send the Message "HI"
            socket.send(toDatagram("HI", InetAddress.getByName("127.0.0.1"), 3800));
            while (true) {
                System.out.println("Sending hi " + i);
                Thread.currentThread();
                Thread.sleep(10000);
                socket.send(toDatagram("HI " + String.valueOf(i), InetAddress.getByName("127.0.0.1"), 3800));
                i++;
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
    public static DatagramPacket toDatagram(String s, InetAddress destIA, int destPort) {
// Deprecated in Java 1.1, but it works:
        byte[] buf = new byte[s.length() + 1];
        s.getBytes(0, s.length(), buf, 0);
// The correct Java 1.1 approach, but it's
// Broken (it truncates the String):
// byte[] buf = s.getBytes();
        return new DatagramPacket(buf, buf.length, destIA, destPort);
    }

    public static void main(String[] args) {
        runJavaSocket();
    }
}
