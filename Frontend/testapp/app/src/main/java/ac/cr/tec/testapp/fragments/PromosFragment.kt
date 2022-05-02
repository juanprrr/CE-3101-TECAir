package ac.cr.tec.testapp.fragments

import ac.cr.tec.testapp.DBContract
import ac.cr.tec.testapp.DatabaseHelper
import ac.cr.tec.testapp.R
import ac.cr.tec.testapp.adapters.PromosRecyclerAdapter
import ac.cr.tec.testapp.models.Promocion
import android.os.AsyncTask
import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.appcompat.widget.AppCompatTextView
import androidx.fragment.app.Fragment
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import kotlinx.android.synthetic.main.fragment_promos.view.*
import kotlinx.android.synthetic.main.item_promo_recycler.*
import kotlinx.android.synthetic.main.item_promo_recycler.view.*

/**
 * Fragmento de actividad home la cual se encarga de mostrar las
 * promociones disponibles.
 */
class PromosFragment : Fragment() {

    //private val activity = this@PromosFragment
    private lateinit var viewOfLayout: View
    private lateinit var textViewCodigo: AppCompatTextView
    private lateinit var recyclerViewUsers: RecyclerView
    private lateinit var listaPromos: MutableList<Promocion>
    private lateinit var usersRecyclerAdapter: PromosRecyclerAdapter
    private lateinit var databaseHelper: DatabaseHelper

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        viewOfLayout = inflater.inflate(R.layout.fragment_promos, container, false)

        databaseHelper = DatabaseHelper(requireActivity())
        recyclerViewUsers = viewOfLayout.findViewById(R.id.recyclerViewUsers)
        recyclerViewUsers.layoutManager = LinearLayoutManager(context)
        listaPromos = mutableListOf<Promocion>() // se inicializa la lista


        // se ingresan promociones en la base de datos local
        val promo1 = Promocion(123, 10,"10 Abril")
        databaseHelper.addPromo(promo1)
        val promo2 = Promocion(321, 50,"16 Marzo")
        databaseHelper.addPromo(promo2)

        consultarPromos()

        usersRecyclerAdapter = PromosRecyclerAdapter(listaPromos)
        recyclerViewUsers.adapter = usersRecyclerAdapter

        return viewOfLayout
    }

    private fun consultarPromos() {
        /**
         * Esta función se encarga de conseguir todas las promociones asociados a TecAir
         * y guardarlas en la lista listaPromos.
         */

        val db = databaseHelper.readableDatabase
        val cursor = db.rawQuery("select * from " + DBContract.PromocionEntry.TABLE_NAME, null)

        while (cursor.moveToNext()){
            var promo = Promocion(cursor.getInt(0), cursor.getInt(1), cursor.getString(2))

            listaPromos.add(promo)
        }
    }


}