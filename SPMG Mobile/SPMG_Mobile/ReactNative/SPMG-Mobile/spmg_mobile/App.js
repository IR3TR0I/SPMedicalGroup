import React from 'react';
import { NavigationContainer} from '@react-navigation/native'
import { createStackNavigator } from '@react-navigation/stack';

import Home from './src/screens/Home'
import Login from './src/screens/Login'
import Main from './src/screens/Main'

const AuthStack = createStackNavigator()

function telas() {

  return(

    <NavigationContainer>

      <AuthStack.Navigator>
        <AuthStack.Screen name= 'Home' component={Home}/>
        <AuthStack.Screen name= 'Login' component={Login}/>
        <AuthStack.Screen name= 'Main' component={Main}/>

      </AuthStack.Navigator>

    </NavigationContainer>
  )
}

export default telas
