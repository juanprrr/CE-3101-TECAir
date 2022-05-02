package ac.cr.tec.testapp.adapters

import ac.cr.tec.testapp.R
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import ac.cr.tec.testapp.models.Vuelo


class FlightsRecyclerAdapter(private val listFlights: List<Vuelo>): RecyclerView.Adapter<FlightsRecyclerAdapter.ViewHolder>() {


    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val view: View = LayoutInflater.from(parent.context)
            .inflate(R.layout.item_flight_recycler, parent, false)
        return ViewHolder(view)
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        holder.textViewId.text = listFlights[position].id.toString()
        holder.textViewEstado.text = listFlights[position].estado.toString()
        holder.textViewCosto.text = listFlights[position].costo.toString()
    }

    override fun getItemCount(): Int {
        return listFlights.size;
    }

    inner class ViewHolder(view: View) : RecyclerView.ViewHolder(view) {

        var textViewId: TextView
        var textViewEstado: TextView
        var textViewCosto: TextView

        init {
            textViewId = view.findViewById<View>(R.id.textViewCodigo) as TextView
            textViewEstado = view.findViewById<View>(R.id.textViewDescuento) as TextView
            textViewCosto = view.findViewById<View>(R.id.textViewVencimiento) as TextView
        }
    }
}
