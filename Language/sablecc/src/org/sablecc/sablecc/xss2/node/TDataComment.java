/* This file was generated by SableCC (http://www.sablecc.org/). */

package org.sablecc.sablecc.xss2.node;

import org.sablecc.sablecc.xss2.analysis.*;

public final class TDataComment extends Token
{
    public TDataComment(String text)
    {
        setText(text);
    }

    public TDataComment(String text, int line, int pos)
    {
        setText(text);
        setLine(line);
        setPos(pos);
    }

    public Object clone()
    {
      return new TDataComment(getText(), getLine(), getPos());
    }

    public void apply(Switch sw)
    {
        ((Analysis) sw).caseTDataComment(this);
    }
}
