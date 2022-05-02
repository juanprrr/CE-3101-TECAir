package ac.cr.tec.testapp

import ac.cr.tec.testapp.adapters.FlightsRecyclerAdapter
import ac.cr.tec.testapp.adapters.PromosRecyclerAdapter
import ac.cr.tec.testapp.models.*
import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.RecyclerView

/**
 * Clase que maneja lógica en activity_flightsres, donde
 * se muestran los vuelos filtrados
 */
class FlightsresActivity: AppCompatActivity() {

    private val activity = this@FlightsresActivity
    private lateinit var recyclerViewFlights: RecyclerView
    private lateinit var listaFlights: MutableList<Vuelo>
    private lateinit var flightsRecyclerAdapter: FlightsRecyclerAdapter
    private lateinit var databaseHelper: DatabaseHelper

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        setContentView(R.layout.activity_flightsres)

        var databaseHelper = DatabaseHelper(activity)

        listaFlights = mutableListOf<Vuelo>() // se inicializa la lista

        val viaje1 = Viaje(16, "SYD-BNA",3564,4985)
        databaseHelper.addViaje(viaje1)

        val ruta1 = Ruta(16, "Ochomogo")
        databaseHelper.addRuta(ruta1)

        val vuelo1 = Vuelo(1111, true, 100,2,16)
        databaseHelper.addFlight(vuelo1)

        //resVuelos()

        //flightsRecyclerAdapter = FlightsRecyclerAdapter(listaFlights)
        //recyclerViewFlights.adapter = flightsRecyclerAdapter
    }


    private fun resVuelos() {

        val db = databaseHelper.readableDatabase

        // se debe buscar en la base de datos los Vuelos que tengan el origen y destino especificados
        val cursor = db.rawQuery("select " + DBContract.VueloEntry.COLUMN_ID + ", " +
                                        DBContract.VueloEntry.COLUMN_ESTADO + ", " +
                                        DBContract.VueloEntry.COLUMN_COSTO +
                                        " from " + DBContract.ViajeEntry.TABLE_NAME  +
                                        " INNER JOIN " + DBContract.RutaEntry.TABLE_NAME +
                                        " on " + DBContract.ViajeEntry.COLUMN_NUMERO + " = " +
                                        DBContract.RutaEntry.COLUMN_ID + " INNER JOIN " +
                                        DBContract.VueloEntry.TABLE_NAME + " on " +
                                        DBContract.RutaEntry.COLUMN_ID + " = " + DBContract.VueloEntry.COLUMN_RUTAASIGN +
                                        " where " + DBContract.ViajeEntry.COLUMN_ORIGENID +
                                        " = " + "3564" + " and " + DBContract.ViajeEntry.COLUMN_DESTINOID + " = " +
                                        "4985", null)

        while (cursor.moveToNext()){
            var vuelo = Vuelo(cursor.getInt(0), cursor.getInt(1) > 1, cursor.getInt(2), cursor.getInt(3),cursor.getInt(4))

            listaFlights.add(vuelo)
        }
    }


}

