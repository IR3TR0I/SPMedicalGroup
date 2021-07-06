import React, { Component } from 'react'
import { StyleSheet, Text, Image, TextInput, View, TouchableOpacity, } from 'react-native'
import AsyncStorage from '@react-native-async-storage/async-storage'
import api from '../services/api'



class Login extends Component {

    constructor(props) {

        super(props)

        this.state = {

            email: '',
            senha: ''

        }
    }


    RealizarLogin = async () => {

        console.warn('email:' + this.state.email + '/' + 'senha:' + this.state.senha)

        try {

            const resposta = await api.post('/Login', {
                email: this.state.email,
                senha: this.state.senha
            })

            const token = resposta.data.token

            console.warn(token)

            await AsyncStorage.setItem('userToken', token)

            this.props.navigation.navigate('Main')

        }

        catch (error) {

            console.warn(error)

        }

    }


    LimparCampos = () => {

        this.setState({ email: '', senha: '' })

    }


    componentDidMount() {

        this.LimparCampos() 

    }


    render() {

        return (

            <View style={styles.main}>


                <View style={styles.header}>  

                    <Image
                        style={styles.hamburger}
                    />

                    <Text style={styles.headerText}>{'clínica sp medical group'.toUpperCase()}</Text>

                    <Image
                        style={styles.logo}
                    />

                </View>


                


                <View style={styles.mainBody}>

                    <View style={styles.loginTitleBox}>
                        <Text style={styles.loginTitle}>{'login'.toUpperCase()}</Text>
                    </View>


                    <TextInput
                        style={styles.inputLogin}
                        onChangeText={email => this.setState({ email })}
                        placeholder='email'
                        placeholderTextColor='#000'
                        keyboardType='email-address'
                    />


                    <TextInput
                        style={styles.inputLogin}
                        onChangeText={senha => this.setState({ senha })}
                        placeholder='senha'
                        placeholderTextColor='#000'
                        keyboardType='default'
                        secureTextEntry={true}
                    />


                    <TouchableOpacity
                        style={styles.btnLogin}
                        onPress={this.RealizarLogin}
                    >

                        <View style={styles.btnLoginBox}>
                            <Text style={styles.btnLoginText}>{'entrar'.toUpperCase()}</Text>
                        </View>

                    </TouchableOpacity>


                </View>


            </View>

        )

    }



}

export default Login


const styles = StyleSheet.create({

    main: {
        flex: 1,
        backgroundColor: '#aefad0',
    },

    header: {
        width: '100%',
        height: 90,
        display: 'flex',
        flexDirection: 'row',
        justifyContent: 'center',
        alignItems: 'center',
    },

    hamburger: {
        width: 40,
        height: 40,
    },

    headerText: {
        fontFamily: 'Roboto',
        fontSize: 14,
        fontWeight: 400,
        color: '#000',
        marginLeft: 25
    },

    logo: {
        width: 70,
        height: 74,
        marginLeft: 30
    },

    

    mainBody: {
        justifyContent: 'center',
        alignItems: 'center'
    },

    loginTitleBox: {
        width: 300,
        height: 50,
        borderRadius: 6,
        marginTop: 40,
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center'
    },

    loginTitle: {
        fontFamily: 'Roboto',
        fontSize: 36,
        color: '#000'
    },

    inputLogin: {
        width: 230,
        height: 36,
        backgroundColor: '#f1f1f1',
        borderRadius: 10,
        marginTop: 50,
        textAlign: 'center',
        fontFamily: 'Roboto',
        fontSize: 24,
    },

    btnLoginBox: {
        width: 200,
        height: 40,
        borderRadius: 12,
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        marginTop: 65
    },

    btnLoginText: {
        fontFamily: 'Roboto', 
        fontSize: 18,
        fontWeight: 400,
        color: '#000' 
    }


})