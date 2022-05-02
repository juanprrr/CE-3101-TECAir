package ac.cr.tec.testapp

import ac.cr.tec.testapp.models.*
import android.annotation.SuppressLint
import android.content.ContentValues
import android.content.Context
import android.database.Cursor
import android.database.sqlite.SQLiteConstraintException
import android.database.sqlite.SQLiteDatabase
import android.database.sqlite.SQLiteException
import android.database.sqlite.SQLiteOpenHelper

// sirve como api
/**
 * DatabaseHelper se encarga de la creación de la base de datos local
 * y sirve como API.
 */
class DatabaseHelper(context: Context) : SQLiteOpenHelper(context, DATABASE_NAME, null, DATABASE_VERSION){

    companion object {
        // If you change the database schema, you must increment the database version.
        val DATABASE_VERSION = 1
        val DATABASE_NAME = "TecAirDB.db"

        val USERTABLE_NAME = DBContract.UserEntry.TABLE_NAME
        val COLUSERCEDULA = DBContract.UserEntry.COLUMN_CEDULA
        val COLUSERNOMBRE = DBContract.UserEntry.COLUMN_NOMBRE
        val COLUSERAPELLIDO1 = DBContract.UserEntry.COLUMN_APELLIDO1
        val COLUSERAPELLIDO2 = DBContract.UserEntry.COLUMN_APELLIDO2
        val COLUSERTEL = DBContract.UserEntry.COLUMN_TEL
        val COLUSERCORREO = DBContract.UserEntry.COLUMN_CORREO
        val COLUSERTIPO = DBContract.UserEntry.COLUMN_TIPO
        val COLUSERPASSWORD = DBContract.UserEntry.COLUMN_PASSWORD
        
        private val SQL_CREATE_USERTABLE =
            "CREATE TABLE " + DBContract.UserEntry.TABLE_NAME + " (" +
                    DBContract.UserEntry.COLUMN_CEDULA + " INTEGER PRIMARY KEY," +
                    DBContract.UserEntry.COLUMN_NOMBRE + " TEXT," +
                    DBContract.UserEntry.COLUMN_APELLIDO1 + " TEXT," +
                    DBContract.UserEntry.COLUMN_APELLIDO2 + " TEXT," +
                    DBContract.UserEntry.COLUMN_TEL + " INTEGER," +
                    DBContract.UserEntry.COLUMN_CORREO + " TEXT," +
                    DBContract.UserEntry.COLUMN_TIPO + " TEXT," +
                    DBContract.UserEntry.COLUMN_PASSWORD + " TEXT)"


        val VUELOTABLE_NAME = DBContract.VueloEntry.TABLE_NAME
        val COLVUELOID = DBContract.VueloEntry.COLUMN_ID
        val COLVUELOESTADO = DBContract.VueloEntry.COLUMN_ESTADO
        val COLVUELOCOSTO = DBContract.VueloEntry.COLUMN_COSTO
        val COLVUELOCANTPASAJEROS = DBContract.VueloEntry.COLUMN_CANTPASAJEROS
        val COLVUELORUTAASIGN = DBContract.VueloEntry.COLUMN_RUTAASIGN


        private val SQL_CREATE_VUELOTABLE =
            "CREATE TABLE " + DBContract.VueloEntry.TABLE_NAME + " (" +
                    DBContract.VueloEntry.COLUMN_ID + " TEXT," +
                    DBContract.VueloEntry.COLUMN_ESTADO + " TEXT," +
                    DBContract.VueloEntry.COLUMN_COSTO + " INTEGER," +
                    DBContract.VueloEntry.COLUMN_CANTPASAJEROS + " INTEGER," +
                    DBContract.VueloEntry.COLUMN_RUTAASIGN + " INTEGER)"

        val RUTATABLE_NAME = DBContract.RutaEntry.TABLE_NAME
        val COLRUTAID = DBContract.RutaEntry.COLUMN_ID
        val COLRUTANOMBRE = DBContract.RutaEntry.COLUMN_NOMBRE

        private val SQL_CREATE_RUTATABLE =
            "CREATE TABLE " + DBContract.RutaEntry.TABLE_NAME + " (" +
                    DBContract.RutaEntry.COLUMN_ID + " INTEGER PRIMARY KEY," +
                    DBContract.RutaEntry.COLUMN_NOMBRE + " TEXT)"

        val RESERVACIONTABLE_NAME = DBContract.ReservacionEntry.TABLE_NAME
        val COLRESID = DBContract.ReservacionEntry.COLUMN_ID
        val COLRESEMI = DBContract.ReservacionEntry.COLUMN_EMISION
        val COLRESVEN = DBContract.ReservacionEntry.COLUMN_VENCIMIENTO
        val COLRESCHEQUEO = DBContract.ReservacionEntry.COLUMN_CHEQUEO

        private val SQL_CREATE_RESERVACIONTABLE =
            "CREATE TABLE " + DBContract.ReservacionEntry.TABLE_NAME + " (" +
                    DBContract.ReservacionEntry.COLUMN_ID + " INTEGER PRIMARY KEY," +
                    DBContract.ReservacionEntry.COLUMN_EMISION + " TEXT," +
                    DBContract.ReservacionEntry.COLUMN_VENCIMIENTO + " TEXT," +
                    DBContract.ReservacionEntry.COLUMN_CHEQUEO + " BOOLEAN)"

        val PROMOTABLE_NAME = DBContract.PromocionEntry.TABLE_NAME
        val COLPROMOCOD = DBContract.PromocionEntry.COLUMN_CODIGO
        val COLPROMODESC = DBContract.PromocionEntry.COLUMN_DESCUENTO
        val COLPROMOVEN = DBContract.PromocionEntry.COLUMN_VENCIMIENTO

        private val SQL_CREATE_PROMOTABLE =
            "CREATE TABLE " + DBContract.PromocionEntry.TABLE_NAME + " (" +
                    DBContract.PromocionEntry.COLUMN_CODIGO + " INTEGER PRIMARY KEY," +
                    DBContract.PromocionEntry.COLUMN_DESCUENTO + " INTEGER," +
                    DBContract.PromocionEntry.COLUMN_VENCIMIENTO + " TEXT)"

        val VIAJETABLE_NAME = DBContract.ViajeEntry.TABLE_NAME
        val COLVIAJENUM = DBContract.ViajeEntry.COLUMN_NUMERO
        val COLVIAJENOM = DBContract.ViajeEntry.COLUMN_NOMBRE
        val COLVIAJEORIGENID = DBContract.ViajeEntry.COLUMN_ORIGENID
        val COLVIAJEDESTINOID = DBContract.ViajeEntry.COLUMN_DESTINOID

        private val SQL_CREATE_VIAJETABLE =
            "CREATE TABLE " + DBContract.ViajeEntry.TABLE_NAME + " (" +
                    DBContract.ViajeEntry.COLUMN_NUMERO + " INTEGER PRIMARY KEY," +
                    DBContract.ViajeEntry.COLUMN_NOMBRE + " TEXT," +
                    DBContract.ViajeEntry.COLUMN_ORIGENID + " INTEGER," +
                    DBContract.ViajeEntry.COLUMN_DESTINOID + " INTEGER)"

        val AEROPTABLE_NAME = DBContract.AeropuertoEntry.TABLE_NAME
        val COLAEROPID = DBContract.AeropuertoEntry.COLUMN_ID
        val COLAEROPNOM = DBContract.AeropuertoEntry.COLUMN_NOMBRE
        val COLAEROPCIUD = DBContract.AeropuertoEntry.COLUMN_CIUDAD
        val COLAEROPPAIS = DBContract.AeropuertoEntry.COLUMN_PAIS

        private val SQL_CREATE_AEROPTABLE =
            "CREATE TABLE " + DBContract.AeropuertoEntry.TABLE_NAME + " (" +
                    DBContract.AeropuertoEntry.COLUMN_ID + " INTEGER PRIMARY KEY," +
                    DBContract.AeropuertoEntry.COLUMN_NOMBRE + " TEXT," +
                    DBContract.AeropuertoEntry.COLUMN_CIUDAD + " TEXT," +
                    DBContract.AeropuertoEntry.COLUMN_PAIS + " TEXT)"



        private val SQL_DELETE_ENTRIES = "DROP TABLE IF EXISTS " + DBContract.UserEntry.TABLE_NAME
        private val SQL_DELETE_ENTRIES2 = "DROP TABLE IF EXISTS " + DBContract.VueloEntry.TABLE_NAME
        private val SQL_DELETE_ENTRIES3 = "DROP TABLE IF EXISTS " + DBContract.RutaEntry.TABLE_NAME
        private val SQL_DELETE_ENTRIES4 = "DROP TABLE IF EXISTS " + DBContract.ReservacionEntry.TABLE_NAME
        private val SQL_DELETE_ENTRIES5 = "DROP TABLE IF EXISTS " + DBContract.PromocionEntry.TABLE_NAME
    }


    override fun onCreate(db: SQLiteDatabase) {
        /**
         * se crean las tablas en la base de datos
         */
        db.execSQL(SQL_CREATE_USERTABLE)
        db.execSQL(SQL_CREATE_VUELOTABLE)
        db.execSQL(SQL_CREATE_RUTATABLE)
        db.execSQL(SQL_CREATE_RESERVACIONTABLE)
        db.execSQL(SQL_CREATE_PROMOTABLE)
        db.execSQL(SQL_CREATE_VIAJETABLE)
        db.execSQL(SQL_CREATE_AEROPTABLE)
    }

    override fun onUpgrade(db: SQLiteDatabase, oldVersion: Int, newVersion: Int) {
        // discard the date and begin again
        db.execSQL(SQL_DELETE_ENTRIES)
        db.execSQL(SQL_DELETE_ENTRIES2)
        db.execSQL(SQL_DELETE_ENTRIES3)
        db.execSQL(SQL_DELETE_ENTRIES4)
        db.execSQL(SQL_DELETE_ENTRIES5)
        onCreate(db)
    }

    override fun onDowngrade(db: SQLiteDatabase?, oldVersion: Int, newVersion: Int) {
        super.onDowngrade(db, oldVersion, newVersion)
    }


    /**
     * Este metodo es para agregar usuario a base de datos
     *
     * @param user
     */
    fun addUser(user: User) {
        val db = this.writableDatabase
        val insertvalues = ContentValues()
        insertvalues.put(DBContract.UserEntry.COLUMN_NOMBRE, user.nombre)
        insertvalues.put(DBContract.UserEntry.COLUMN_APELLIDO1, user.apellidouno)
        insertvalues.put(DBContract.UserEntry.COLUMN_APELLIDO2, user.apellidodos)
        insertvalues.put(DBContract.UserEntry.COLUMN_CEDULA, user.cedula)
        insertvalues.put(DBContract.UserEntry.COLUMN_CORREO, user.correo)
        insertvalues.put(DBContract.UserEntry.COLUMN_PASSWORD, user.password)
        insertvalues.put(DBContract.UserEntry.COLUMN_TEL, user.tel)
        insertvalues.put(DBContract.UserEntry.COLUMN_TIPO, user.tipo)
        // Inserting Row
        db.insert(USERTABLE_NAME, null, insertvalues)
        db.close() // cierra conexion con base de datos
    }

    /**
     * Este metodo es para agregar promocion a base de datos
     */
    fun addPromo(promo: Promocion) {
        val db = this.writableDatabase
        val insertvalues = ContentValues()
        insertvalues.put(DBContract.PromocionEntry.COLUMN_CODIGO, promo.codigo)
        insertvalues.put(DBContract.PromocionEntry.COLUMN_DESCUENTO, promo.descuento)
        insertvalues.put(DBContract.PromocionEntry.COLUMN_VENCIMIENTO, promo.vencimiento)
        // Inserting Row
        db.insert(PROMOTABLE_NAME, null, insertvalues)
        db.close()
    }

    /**
     * Este metodo es para agregar aeropuerto a base de datos
     */
    fun addAP(ap: Aeropuerto) {
        val db = this.writableDatabase
        val insertvalues = ContentValues()
        insertvalues.put(DBContract.AeropuertoEntry.COLUMN_ID, ap.id)
        insertvalues.put(DBContract.AeropuertoEntry.COLUMN_NOMBRE, ap.nombre)
        insertvalues.put(DBContract.AeropuertoEntry.COLUMN_CIUDAD, ap.ciudad)
        insertvalues.put(DBContract.AeropuertoEntry.COLUMN_PAIS, ap.pais)
        // Inserting Row
        db.insert(AEROPTABLE_NAME, null, insertvalues)
        db.close()
    }

    fun addFlight(fl: Vuelo) {
        /**
         * Este metodo es para agregar vuelo a base de datos
         */
        val db = this.writableDatabase
        val insertvalues = ContentValues()
        insertvalues.put(DBContract.VueloEntry.COLUMN_ID, fl.id)
        insertvalues.put(DBContract.VueloEntry.COLUMN_ESTADO, fl.estado)
        insertvalues.put(DBContract.VueloEntry.COLUMN_COSTO, fl.costo)
        insertvalues.put(DBContract.VueloEntry.COLUMN_CANTPASAJEROS, fl.cantPasajeros)
        insertvalues.put(DBContract.VueloEntry.COLUMN_RUTAASIGN, fl.rutaAsign)
        // Inserting Row
        db.insert(VUELOTABLE_NAME, null, insertvalues)
        db.close()
    }

    fun addRuta(rt: Ruta) {
        /**
         * Este metodo es para agregar ruta a base de datos
         */
        val db = this.writableDatabase
        val insertvalues = ContentValues()
        insertvalues.put(DBContract.RutaEntry.COLUMN_ID, rt.id)
        insertvalues.put(DBContract.RutaEntry.COLUMN_NOMBRE, rt.nombre)
        // Inserting Row
        db.insert(RUTATABLE_NAME, null, insertvalues)
        db.close()
    }

    fun addViaje(vj: Viaje) {
        /**
         * Este metodo es para agregar viaje a base de datos
         */
        val db = this.writableDatabase
        val insertvalues = ContentValues()
        insertvalues.put(DBContract.ViajeEntry.COLUMN_NUMERO, vj.numero)
        insertvalues.put(DBContract.ViajeEntry.COLUMN_NOMBRE, vj.nombre)
        insertvalues.put(DBContract.ViajeEntry.COLUMN_ORIGENID, vj.origenid)
        insertvalues.put(DBContract.ViajeEntry.COLUMN_DESTINOID, vj.destinoid)
        // Inserting Row
        db.insert(VIAJETABLE_NAME, null, insertvalues)
        db.close()
    }


    /**
     * Metodo para eliminar usuario según cedula especificada
     */
    @Throws(SQLiteConstraintException::class)
    fun deleteData(id: String): Int {
        // Gets the data repository in write mode
        val db = writableDatabase
        // Define 'where' part of query.
        val selection = DBContract.UserEntry.COLUMN_CEDULA + " LIKE ?"
        // Specify arguments in placeholder order.
        val selectionArgs = arrayOf(id)
        // SQL statement which will return number of rows deleted
        val action = db.delete(DBContract.UserEntry.TABLE_NAME, selection, selectionArgs)
        db.close()
        return action
    }

    /**
     * metodo para obtener array de los usuarios en base de datos
     */
    fun readUsers(): ArrayList<User> {
        val dBdata = ArrayList<User>()
        val db = writableDatabase
        var cursor: Cursor? = null
        try {
            cursor = db.rawQuery("select * from " + DBContract.UserEntry.TABLE_NAME, null)

        } catch (e: SQLiteException) {
            db.execSQL(SQL_CREATE_USERTABLE)
            return ArrayList()
        }

        var cedula: Int
        var nombre: String
        var apellido1: String
        var apellido2: String
        var tel: Int
        var correo: String
        var tipo: String
        var password: String

        if (cursor!!.moveToFirst()) {
            while (cursor.isAfterLast == false) {
                nombre = cursor.getString(cursor.getColumnIndexOrThrow(DBContract.UserEntry.COLUMN_NOMBRE))
                apellido1 = cursor.getString(cursor.getColumnIndexOrThrow(DBContract.UserEntry.COLUMN_APELLIDO1))
                apellido2 = cursor.getString(cursor.getColumnIndexOrThrow(DBContract.UserEntry.COLUMN_APELLIDO2))
                cedula = cursor.getInt(cursor.getColumnIndexOrThrow(DBContract.UserEntry.COLUMN_CEDULA))
                tipo = cursor.getString(cursor.getColumnIndexOrThrow(DBContract.UserEntry.COLUMN_TIPO))
                password = cursor.getString(cursor.getColumnIndexOrThrow(DBContract.UserEntry.COLUMN_PASSWORD))
                tel = cursor.getInt(cursor.getColumnIndexOrThrow(DBContract.UserEntry.COLUMN_TEL))
                correo = cursor.getString(cursor.getColumnIndexOrThrow(DBContract.UserEntry.COLUMN_CORREO))

                dBdata.add(User(nombre, apellido1, apellido2, cedula, tipo, password, tel, correo))
                cursor.moveToNext()
            }
        }
        return dBdata
    }

    /**
     * Revisa si existe un usuario con un correo dado
     */
    fun checkUser(email: String): Boolean {
        // array of columns to fetch
        val columns = arrayOf(COLUSERCORREO)
        val db = this.readableDatabase
        // selection criteria
        val selection = "$COLUSERCORREO = ?"
        // selection argument
        val selectionArgs = arrayOf(email)
        // query user table with condition

        val cursor = db.query(
            USERTABLE_NAME, //Table to query
            columns,        //columns to return
            selection,      //columns for the WHERE clause
            selectionArgs,  //The values for the WHERE clause
            null,  //group the rows
            null,   //filter by row groups
            null)  //The sort order
        val cursorCount = cursor.count
        cursor.close()
        db.close()
        if (cursorCount > 0) {
            return true
        }
        return false
    }

    /**
     * Revisa si existe un usuario con un
     * correo y contraseña dada
     */
    fun checkUser(email: String, password: String): Boolean {
        // array of columns to fetch
        val columns = arrayOf(COLUSERCEDULA)
        val db = this.readableDatabase
        // selection criteria
        val selection = "$COLUSERCORREO = ? AND $COLUSERPASSWORD = ?"
        // selection arguments
        val selectionArgs = arrayOf(email, password)
        // query user table with conditions

        val cursor = db.query(
            USERTABLE_NAME, //Table to query
            columns, //columns to return
            selection, //columns for the WHERE clause
            selectionArgs, //The values for the WHERE clause
            null,  //group the rows
            null, //filter by row groups
            null) //The sort order
        val cursorCount = cursor.count
        cursor.close()
        db.close()
        if (cursorCount > 0)
            return true
        return false
    }


}