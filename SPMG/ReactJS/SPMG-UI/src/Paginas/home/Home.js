import { Link } from 'react-router-dom'
import '../../css/Home.css'

function Home() {  

  return (

    <div>

     

      <main>

        <div className="content-home">

          <div className="banner">

            <div className="banner-content">

              

              <p>Conheça a clínica SP Medical Group e nossas especialidades</p>

            </div>

          </div>

          <div className="options">

            <div className="options-content">

              <Link to="login">
                <div className="search">
                  <p>VER CONSULTAS</p>
                </div>
              </Link>

              <Link to="cadastro">
                <div className="calendar">
                  
                  <p>AGENDAR CONSULTA</p>
                </div>
              </Link>

              <Link to="/">
                <div className="ambulance">
                  
                  <p>CORPO CLÍNICO</p>
                </div>
              </Link>


            </div>


          </div>


        </div>



      </main>


      


    </div>

  )

}

export default Home;
