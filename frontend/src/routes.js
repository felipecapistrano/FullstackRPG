import React from "react"
import { BrowserRouter, Switch, Route } from "react-router-dom"

import Home from "./Pages/Home"
import Guild from "./Pages/Guild"
import Plaza from "./Pages/Plaza"
import Forge from "./Pages/Forge"
import Library from "./Pages/Library"
import Dojo from "./Pages/Dojo"

function Routes() {
    return (
        <BrowserRouter>
            <Switch>
                <Route path="/" exact component ={Home}/>
                <Route path="/Plaza" component ={Plaza}/>
                <Route path="/Guild" component ={Guild}/>
                <Route path="/Forge" component ={Forge}/>
                <Route path="/Library" component ={Library}/>
                <Route path="/Dojo" component ={Dojo}/>
            </Switch>
        </BrowserRouter>
    )
}

export default Routes