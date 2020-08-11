import React, {useState} from "react"
import WeaponScript from "./Components/Scripts/WeaponScript"
import HelmScript from "./Components/Scripts/HelmScript"
import ArmorScript from "./Components/Scripts/ArmorScript"
import SideBar from "./Components/SideBar"
import "../Styles/background.css"
import "../Styles/fade.css"
import MaterialScript from "./Components/Scripts/MaterialScript"

function Forge() {
    const [weapon, setWeapon] = useState(false)
    const [helm, setHelm] = useState(false)
    const [armor, setArmor] = useState(false)
    const [material, setMaterial] = useState(false)

    function includes(fun, e) {
        const scripts = [weapon, helm, armor, material]
        if (!scripts.includes(true))
            fun(e)
    }

    const sideButtons = [
        {name: "Forjar arma", script: (e) => includes(setWeapon, e)},
        {name: "Forjar capacete", script: (e) => includes(setHelm, e)},
        {name: "Forjar armadura", script: (e) => includes(setArmor, e)},
        {name: "Entregar material", script: (e) => includes(setMaterial, e)},
        {name: "Voltar", changescene: "/Plaza", element: "forge"}
    ]
    
    return (
        <div id="forge" className="fadein">
            <SideBar sideButtons={sideButtons}/>
            {weapon && <WeaponScript end={(e) => setWeapon(e)}/>}
            {helm && <HelmScript end={(e) => setHelm(e)}/>}
            {armor && <ArmorScript end={(e) => setArmor(e)}/>}
            {material && <MaterialScript end={(e) => setMaterial(e)}/>}
        </div>
    )
}

export default Forge