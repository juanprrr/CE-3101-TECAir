package ac.cr.tec.testapp.models

import java.util.*

// Puede que haya fallo por tipo Date, por ejemploen bind de PromosFragment. Creo que no
data class Promocion(var codigo:Int, var descuento:Int, var vencimiento:String){
}