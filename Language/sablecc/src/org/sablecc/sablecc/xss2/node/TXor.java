/* This file was generated by SableCC (http://www.sablecc.org/). */

package org.sablecc.sablecc.xss2.node;

import org.sablecc.sablecc.xss2.analysis.*;

public final class TXor extends Token
{
    public TXor()
    {
        super.setText("or");
    }

    public TXor(int line, int pos)
    {
        super.setText("or");
        setLine(line);
        setPos(pos);
    }

    public Object clone()
    {
      return new TXor(getLine(), getPos());
    }

    public void apply(Switch sw)
    {
        ((Analysis) sw).caseTXor(this);
    }

    public void setText(String text)
    {
        throw new RuntimeException("Cannot change TXor text.");
    }
}
