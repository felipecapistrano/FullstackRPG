import React from "react"
import LinkButton from "./Buttons/LinkButton"
import "../Styles/sidebar.css"

function SideBar(props) {
    const buttons = props.sideButtons.map(function(item) {
        if (!item.changescene) {
            return (
                <button onClick={() => item.script(true)} className="sidebar-button">
                    {item.name}
                </button>
            )
        }
        else {
            return <LinkButton 
                    url={item.changescene} 
                    text={item.name} 
                    classes={"sidebar-button"} 
                    element={item.element}
                    />
        }
    })
    return (
        <div id="sidebar">
            {buttons}
        </div>
    )
}

export default SideBar