package ac.cr.tec.testapp

import ac.cr.tec.testapp.models.User
import android.content.Intent
import android.os.Bundle
import android.view.View
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import androidx.core.widget.NestedScrollView

class RegisterActivity: AppCompatActivity() {

    private val activity = this@RegisterActivity
    private lateinit var databaseHelper: DatabaseHelper
    private lateinit var nestedScrollView: NestedScrollView


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        setContentView(R.layout.activity_register)
        databaseHelper = DatabaseHelper(activity)

        val regButton = findViewById<Button>(R.id.appCompatButtonRegister)
        val loginLink = findViewById<TextView>(R.id.appCompatTextViewLoginLink)
        regButton.setOnClickListener{
            postDataToSQLite()
        }

        loginLink.setOnClickListener { finish() }
    }

    /**
     * se crea el objeto User con la información suministrada
     * y se llama método addUser del Helper.
     */
    private fun postDataToSQLite() {
        val fname = findViewById<EditText>(R.id.textInputEditTextFName).text.toString()
        val lname1 = findViewById<EditText>(R.id.textInputEditTextLName1).text.toString()
        val lname2 = findViewById<EditText>(R.id.textInputEditTextLName2).text.toString()
        val tipo = findViewById<EditText>(R.id.textInputEditTextTipo).text.toString()
        val tel = findViewById<EditText>(R.id.textInputEditTextPN).text.toString().toInt()
        val email = findViewById<EditText>(R.id.textInputEditTextEmail).text.toString()
        val password = findViewById<EditText>(R.id.textInputEditTextPassword).text.toString()
        val cedula = findViewById<EditText>(R.id.textInputEditTextCedula).text.toString().toInt()
        //
        if (!databaseHelper!!.checkUser(email.trim())) {
            var user = User(nombre = fname.trim(),
                apellidouno = lname1.trim(),
                apellidodos = lname2.trim(),
                cedula = cedula,
                tipo = tipo.trim(),
                tel = tel,
                correo = email.trim(),
                password = password.trim(),

            )
            databaseHelper!!.addUser(user)
            // Snack Bar to show success message that record saved successfully
            Toast.makeText(this, getString(R.string.success_message), Toast.LENGTH_SHORT).show()

            emptyInputEditText()
        } else {
            // Snack Bar to show error message that record already exists
            Toast.makeText(this, getString(R.string.error_email_exists), Toast.LENGTH_SHORT).show()
        }
    }

    /**
     * Se encarga de limpiar los inputs
     */
    private fun emptyInputEditText() {
        findViewById<EditText>(R.id.textInputEditTextFName)!!.text = null
        findViewById<EditText>(R.id.textInputEditTextLName1)!!.text = null
        findViewById<EditText>(R.id.textInputEditTextLName2)!!.text = null
        findViewById<EditText>(R.id.textInputEditTextTipo)!!.text = null
        findViewById<EditText>(R.id.textInputEditTextPN)!!.text = null
        findViewById<EditText>(R.id.textInputEditTextEmail)!!.text = null
        findViewById<EditText>(R.id.textInputEditTextPassword)!!.text = null
        findViewById<EditText>(R.id.textInputEditTextCedula)!!.text = null
    }
}