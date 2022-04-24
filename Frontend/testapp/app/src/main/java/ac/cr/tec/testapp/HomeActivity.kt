package ac.cr.tec.testapp

import ac.cr.tec.testapp.fragments.FlightsFragment
import ac.cr.tec.testapp.fragments.PromosFragment
import android.content.Intent
import android.os.Bundle
import android.widget.Button
import android.widget.FrameLayout
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import androidx.fragment.app.Fragment
import kotlinx.android.synthetic.main.activity_home.*

class HomeActivity: AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_home)

        val flightsFragment = FlightsFragment()
        val promosFragment = PromosFragment()

        makeCurrentFragment(flightsFragment)

        bottom_nav.setOnItemSelectedListener {
            when (it.itemId){
                R.id.ic_vuelos -> makeCurrentFragment(flightsFragment)
                R.id.ic_promos -> makeCurrentFragment(promosFragment)
            }
            true
        }
    }

    private fun makeCurrentFragment(fragment: Fragment) =
        supportFragmentManager.beginTransaction().apply {
            replace(R.id.fl_wrapper,fragment)
            commit()
        }
    fun goReg(){
        val intent = Intent(this, RegisterActivity::class.java)
        startActivity(intent)
    }

}