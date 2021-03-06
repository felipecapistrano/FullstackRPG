import React from "react"
import LinkButton from "./Buttons/LinkButton"
import "../../Styles/sidebar.css"

function SideBar(props) {
    let key = 0
    const buttons = props.sideButtons.map(function(item) {
        item.key = key
        key += 1
        if (!item.changescene) {
            return (
                <button onClick={() => item.script(true)} className="sidebar-button" key={item.key}>
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
                    key={item.key}
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