package ac.cr.tec.testapp

import ac.cr.tec.testapp.adapters.FlightsRecyclerAdapter
import ac.cr.tec.testapp.adapters.PromosRecyclerAdapter
import ac.cr.tec.testapp.models.Promocion
import ac.cr.tec.testapp.models.Vuelo
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
    }
/*
    private fun resVuelos() {

        val db = databaseHelper.readableDatabase

        // se debe buscar en la base de datos los Vuelos que tengan el origen y destino especificados
        val cursor = db.rawQuery("select " + DBContract.VueloEntry.COLUMN_ID + "," +
                                        DBContract.VueloEntry.COLUMN_ESTADO + "," +
                                        DBContract.VueloEntry.COLUMN_COSTO +
                                        " from " + DBContract.VueloEntry.TABLE_NAME  +
                                        " INNER JOIN " + DBContract.RutaEntry.TABLE_NAME +
                                        " on " + DBContract.VueloEntry.COLUMN_ID + " = " +
                                        DBContract.RutaEntry.COLUMN_ID + " INNER JOIN " +
                                        DBContract.ViajeEntry.TABLE_NAME + " on " +
                                        DBContract.ViajeEntry.COLUMN_NUMERO + " = " + DBContract.RutaEntry.COLUMN_ID +
                                        " where " + DBContract.VueloEntry.COLUMN_ID +
                                        " = " + DBContract.RutaEntry.COLUMN_ID, null)

        while (cursor.moveToNext()){
            var vuelo = Vuelo(cursor.getInt(0), cursor.getInt(1) > 1, cursor.getInt(2), cursor.getInt(3))

            listaFlights.add(vuelo)
        }
    } */
}

