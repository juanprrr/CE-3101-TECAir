package ac.cr.tec.testapp

import android.provider.BaseColumns

object DBContract {
    class UserEntry : BaseColumns {
        companion object {
            val TABLE_NAME = "usuario"

            val COLUMN_NOMBRE = "nombre"
            val COLUMN_APELLIDO1 = "apellidouno"
            val COLUMN_APELLIDO2 = "apellidodos"
            val COLUMN_CEDULA = "cedula"
            val COLUMN_TIPO = "tipo"
            val COLUMN_PASSWORD = "password"
            val COLUMN_TEL = "tel"
            val COLUMN_CORREO = "correo"
        }
    }
}