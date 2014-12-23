using System;

namespace Server {
  public class Server: IServer {
    private Deck deck = new Deck();

    public Int16 GetCard() {
      return deck.GetCard();
    }
  }
}