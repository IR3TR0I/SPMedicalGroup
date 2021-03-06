import { React, Component } from 'react'
import axios from 'axios';
import '../../css/ListarConsultaPaciente.css'

class ListarConsultasPaciente extends Component {


    constructor(props) {

        super(props)

        this.state = {
            listaConsultas: [],
            listaMedicos: [],
            listaPacientes: [],
            listaSituacoes: [],
            isLoading: false
        }

    }




    BuscarConsultasPac = () => {


        this.setState({ isLoading: true })


        axios('http://localhost:5000/api/consultas/paclist', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

            .then(resposta => {

                if (resposta.status === 200) {

                    this.setState({ listaConsultas: resposta.data, isLoading: false })

                    console.log(this.state.listaConsultas)

                }

            })

            .catch(erro => {

                console.log(erro)

                this.setState({ isLoading: false })
            })

    }



    LimparLista = () => {

        this.setState({ listaConsultas: [] })

        console.log('A tabela foi limpa')
    }



    componentDidMount() {

    }



    render() {

        return (

            <div>

                

                <main>

                    <section className="content-lista">

                        <div className="user-box">
                            <p>PACIENTE</p>
                        </div>

                        <div className="titulo-listar">
                            <h1>LISTA DE CONSULTAS</h1>
                        </div>


                        <button
                            className="btn-listar"
                            type="button"
                            onClick={this.BuscarConsultasPac}>
                            Listar Consultas
                        </button>

                        <button
                            className="btn-listar"
                            type="button"
                            onClick={this.LimparLista}>
                            Limpar Lista
                        </button>


                        

                        <section className="lista-consultas">

                            <table className="tabela-lista">

                                <thead>
                                    <tr>
                                        <th>N??MERO DA CONSULTA</th>
                                        <th>M??DICO</th>
                                        <th>PACIENTE</th>
                                        <th>SITUA????O</th>
                                        <th>DATA DA CONSULTA</th>
                                        <th>DESCRI????O</th>
                                    </tr>
                                </thead>

                                <tbody>

                                    {
                                        this.state.listaConsultas.map(consulta => {

                                            return (

                                                <tr key={consulta.idConsulta}>

                                                    <td>{consulta.idConsulta}</td>
                                                    <td>{consulta.idMedicoNavigation.nomeMedico}</td>
                                                    <td>{consulta.idPacienteNavigation.nomePaciente}</td>
                                                    <td>{consulta.idSituacaoNavigation.descricaoSituacao}</td>
                                                    <td>{consulta.dataConsulta.split('T')[0].split('-').reverse().join('/')}</td>
                                                    <td>{consulta.descricao}</td>

                                                </tr>

                                            )

                                        })
                                    }

                                </tbody>

                            </table>


                        </section>

                    </section>


                </main>

               

            </div>

        )

    }

}


export default ListarConsultasPaciente