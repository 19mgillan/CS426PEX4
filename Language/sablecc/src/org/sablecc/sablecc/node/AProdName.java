/* This file was generated by SableCC (http://www.sablecc.org/). */

package org.sablecc.sablecc.node;

import java.util.*;
import org.sablecc.sablecc.analysis.*;

public final class AProdName extends PProdName
{
    private TId _id_;
    private TId _prod_name_tail_;

    public AProdName ()
    {
    }

    public AProdName (
            TId _id_,
            TId _prod_name_tail_
    )
    {
        setId (_id_);
        setProdNameTail (_prod_name_tail_);
    }

    public Object clone()
    {
        return new AProdName (
            (TId)cloneNode (_id_),
            (TId)cloneNode (_prod_name_tail_)
        );
    }

    public void apply(Switch sw)
    {
        ((Analysis) sw).caseAProdName(this);
    }

    public TId getId ()
    {
        return _id_;
    }

    public void setId (TId node)
    {
        if(_id_ != null)
        {
            _id_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        _id_ = node;
    }
    public TId getProdNameTail ()
    {
        return _prod_name_tail_;
    }

    public void setProdNameTail (TId node)
    {
        if(_prod_name_tail_ != null)
        {
            _prod_name_tail_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        _prod_name_tail_ = node;
    }

    public String toString()
    {
        return ""
            + toString (_id_)
            + toString (_prod_name_tail_)
        ;
    }

    void removeChild(Node child)
    {
        if ( _id_ == child )
        {
            _id_ = null;
            return;
        }
        if ( _prod_name_tail_ == child )
        {
            _prod_name_tail_ = null;
            return;
        }
    }

    void replaceChild(Node oldChild, Node newChild)
    {
        if ( _id_ == oldChild )
        {
            setId ((TId) newChild);
            return;
        }
        if ( _prod_name_tail_ == oldChild )
        {
            setProdNameTail ((TId) newChild);
            return;
        }
    }

}
