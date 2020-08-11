import React, {useState} from "react"
import SideBar from "./Components/SideBar"
import RaceScript from "./Components/Scripts/RaceScript"
import WeaponTypeScript from "./Components/Scripts/WeaponTypeScript"
import "../Styles/background.css"
import "../Styles/fade.css"

function Library() {
    const [race, setRace] = useState(false)
    const [weaponType, setWeaponType] = useState(false)

    function includes(fun, e) {
        const scripts = [race, weaponType]
        if (!scripts.includes(true))
            fun(e)
    }

    const sideButtons = [
        {name: "Identificar raças", script: (e) => includes(setRace, e)},
        {name: "Identificar tipos de arma", script: (e) => includes(setWeaponType, e)},
        {name: "Voltar", changescene: "/Plaza", element: "library"}
    ]
    
    return (
        <div id="library" className="fadein">
            <SideBar sideButtons={sideButtons}/>
            {race && <RaceScript end={(e) => setRace(e)}/>}
            {weaponType && <WeaponTypeScript end={(e) => setWeaponType(e)}/>}
        </div>
    )
}

export default Library