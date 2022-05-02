package ac.cr.tec.testapp.adapters

import ac.cr.tec.testapp.R
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import androidx.recyclerview.widget.RecyclerView.Adapter
import ac.cr.tec.testapp.models.Promocion
import androidx.appcompat.widget.AppCompatTextView
import kotlinx.android.synthetic.main.item_promo_recycler.view.*


class PromosRecyclerAdapter(private val listPromos: List<Promocion>): RecyclerView.Adapter<PromosRecyclerAdapter.ViewHolder>() {
    /**
     * PromosRecyclerAdapter sirve como puente entre la lista de promociones y
     * el Recycler View que mostrará las promociones
     */

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val view: View = LayoutInflater.from(parent.context)
            .inflate(R.layout.item_promo_recycler, parent, false)
        return ViewHolder(view)
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        holder.textViewCodigo.text = listPromos[position].codigo.toString()
        holder.textViewDescuento.text = listPromos[position].descuento.toString()
        holder.textViewVencimiento.text = listPromos[position].vencimiento.toString()
    }

    override fun getItemCount(): Int {
        return listPromos.size;
    }

    inner class ViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        /**
         * Asocia cada elemento de una lista de promociones a una fila del
         * Recycler View.
         */
        var textViewCodigo: TextView
        var textViewDescuento: TextView
        var textViewVencimiento: TextView

        init {
            textViewCodigo = view.findViewById<View>(R.id.textViewCodigo) as TextView
            textViewDescuento = view.findViewById<View>(R.id.textViewDescuento) as TextView
            textViewVencimiento = view.findViewById<View>(R.id.textViewVencimiento) as TextView
        }
    }
}