import React, { Component } from 'react'
import { StyleSheet, Text, Image, View, TouchableOpacity, } from 'react-native'
import AsyncStorage from '@react-native-async-storage/async-storage'

class Home extends Component {

    constructor(props) {
        super(props)
    }

    GetToken = async () => {

        const valorToken = await AsyncStorage.getItem('userToken')

    }

    componentDidMount() {
        this.GetToken()
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

                    <Image
                        
                        style={styles.homeImg}
                    />


                    <Text style={styles.homeText}>{'sp medical group'.toUpperCase()}</Text>


                    <TouchableOpacity
                        onPress={() => this.props.navigation.navigate('Login')}
                    >


                        <View style={styles.linkLogin}>

                            <Text style={styles.linkLoginText}>{'login'.toUpperCase()}</Text>

                        </View>

                    </TouchableOpacity>


                </View>


            </View>

        )

    }
}


export default Home



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

    homeImg: {
        width: 300,
        height: 300,
        marginTop: 20
    },

    homeText: {
        fontFamily: 'Roboto',
        fontSize: 18,
        marginTop: 25
    },

    linkLogin: {
        width: 200,
        height: 40,
        borderRadius: 6,
        marginTop: 25,
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center'
    },

    linkLoginText: {
        fontFamily: 'Roboto',
        fontSize: 18,
        fontWeight: 700
    }

})