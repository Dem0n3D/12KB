using System;

namespace Server {
  public class Deck {
    private Boolean[] deck = new Boolean[36];
    private Int16 size = 36;
    private Random generator = new Random(1337);
    public Deck() {
      for (int i = 0; i < 36; i++) {
        deck[i] = true;
      }
    }
    public Int16 GetCard() {
      Int16 count = (short) generator.Next(size),
        curPosition;
      for (curPosition = -1; count > 0;) {
        if (deck[++curPosition]) count--;
      }
      deck[curPosition] = false;
      return curPosition;
    }
  }
}