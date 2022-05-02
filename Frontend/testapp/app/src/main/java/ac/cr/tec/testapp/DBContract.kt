package ac.cr.tec.testapp

import android.provider.BaseColumns
import android.widget.TableLayout

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

    class VueloEntry : BaseColumns {
        companion object {
            val TABLE_NAME = "vuelo"

            val COLUMN_ID = "id"
            val COLUMN_ESTADO = "estado"
            val COLUMN_COSTO = "costo"
        }
    }

    class RutaEntry : BaseColumns {
        companion object {
            val TABLE_NAME = "ruta"

            val COLUMN_ID = "ID"
            val COLUMN_NOMBRE = "nombre"
        }
    }

    class ReservacionEntry : BaseColumns {
        companion object {
            val TABLE_NAME = "reservacion"

            val COLUMN_ID = "ID"
            val COLUMN_EMISION = "emision"
            val COLUMN_VENCIMIENTO = "vencimiento"
            val COLUMN_CHEQUEO = "chequeo"
        }
    }

    class PromocionEntry : BaseColumns {
        companion object {
            val TABLE_NAME = "promocion"

            val COLUMN_CODIGO = "codigo"
            val COLUMN_DESCUENTO = "descuento"
            val COLUMN_VENCIMIENTO = "vencimiento"
        }
    }

    class ViajeEntry : BaseColumns {
        companion object {
            val TABLE_NAME = "viaje"

            val COLUMN_NUMERO = "numero"
            val COLUMN_NOMBRE = "nombre"
        }
    }

    class AeropuertoEntry: BaseColumns {
        companion object {
            val TABLE_NAME = "aeropuerto"

            val COLUMN_ID = "id"
            val COLUMN_NOMBRE = "nombre"
            val COLUMN_CIUDAD = "ciudad"
            val COLUMN_PAIS = "pais"
        }
    }

}