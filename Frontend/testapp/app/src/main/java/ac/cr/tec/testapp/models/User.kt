package ac.cr.tec.testapp.models

data class User(var nombre:String,
                var apellidouno:String,
                var apellidodos:String,
                var cedula:Int,
                var tipo:String,
                var password: String,
                var tel:Int,
                var correo:String){
}