package ac.cr.tec.testapp

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.EditText
import android.widget.Toast
import androidx.core.widget.NestedScrollView


class MainActivity : AppCompatActivity() {

    private val activity = this@MainActivity
    private lateinit var databaseHelper: DatabaseHelper
    private lateinit var nestedScrollView: NestedScrollView

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        setContentView(R.layout.activity_main)
        databaseHelper = DatabaseHelper(activity)

    }

    fun goHome(view: View){
        val intent = Intent(this, HomeActivity::class.java)
        startActivity(intent)
    }

    fun goToRegister(view: View){
        val intent = Intent(this, RegisterActivity::class.java)
        startActivity(intent)
    }

    fun login(view: View) {
        val email = findViewById<EditText>(R.id.emailInput).text.toString()
        val password = findViewById<EditText>(R.id.passwordInput).text.toString()

        // se valida si usuario se encuentra en la base de datos

        if (databaseHelper!!.checkUser(email!!.trim { it <= ' ' }, password!!.trim { it <= ' ' })) {

            emptyInputEditText()

            val intent = Intent(this, HomeActivity::class.java)
            startActivity(intent)
        } else {
            // Snack Bar to show success message that record is wrong
            Toast.makeText(this, "Invalid email or password", Toast.LENGTH_SHORT).show()
           // Snackbar.make(view, getString(R.string.error_valid_email_password), Snackbar.LENGTH_LONG).show()
        }

    }


    private fun emptyInputEditText() {
        findViewById<EditText>(R.id.emailInput)!!.text = null
        findViewById<EditText>(R.id.passwordInput)!!.text = null
    }
}