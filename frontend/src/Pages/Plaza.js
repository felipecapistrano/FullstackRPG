import React from "react"
import Sidebar from "./Components/SideBar"
import "../Styles/background.css"
import "../Styles/fade.css"

function Plaza() {
    const sideButtons = [
        {name: "Ir para guilda", changescene: "/Guild", element: "plaza"},
        {name: "Ir para forja", changescene: "/Forge", element: "plaza"},
        {name: "Ir para biblioteca", changescene: "/Library", element: "plaza"},
        {name: "Ir para dojo", changescene: "/Dojo", element: "plaza"}
    ]
    
    return (
        <div id="plaza" className="fadein">
            <Sidebar sideButtons={sideButtons}/>
        </div>
    )
}

export default Plaza