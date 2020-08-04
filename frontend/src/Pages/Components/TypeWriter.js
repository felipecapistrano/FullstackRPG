import React from "react";
import { useWindupString } from "windups";

function TypeWriter(props) {
  const [text] = useWindupString(
        props.text,
        {
            onChar: () => props.end(false),
            onFinished: () => {
                props.end(true)
            },
        }
      );

  return (
        <span id="text">{text}</span>
    );
};

export default TypeWriter