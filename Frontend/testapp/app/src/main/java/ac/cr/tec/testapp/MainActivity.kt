package ac.cr.tec.testapp

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.EditText
import android.widget.Toast

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
    }

    fun login(view: View) {
        val email = findViewById<EditText>(R.id.emailInput).text.toString()
        val password = findViewById<EditText>(R.id.passwordInput).text.toString()

        // se valida si usuario se encuentra en la base de datos
        if(email == "a@b.com" && password == "abcom1") {
            val intent = Intent(this, HomeActivity::class.java)
            startActivity(intent)
        }else {
            Toast.makeText(this, "Invalid email or password", Toast.LENGTH_SHORT).show()
        }
    }
}