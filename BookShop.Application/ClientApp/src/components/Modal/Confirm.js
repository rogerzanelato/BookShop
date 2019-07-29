import React from "react";
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from "reactstrap";
import { render } from "react-dom";

let resolve;

export default class Confirm extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      isOpen: false,
      question: null,
      questionBody: null
    };
  }

  // rest of the componet
  handleCancel = () => {
    this.setState({ isOpen: false });
    resolve(false);
  };

  handleConfirm = () => {
    this.setState({ isOpen: false });
    resolve(true);
  };

  show = (question, questionBody) => {
    this.setState({ isOpen: true, question, questionBody });
    return new Promise(res => {
      resolve = res;
    });
  };

  static create() {
    const containerElement = document.createElement("div");
    document.body.appendChild(containerElement);
    return render(<Confirm />, containerElement);
  }

  render() {
    return (
      <Modal isOpen={this.state.isOpen}>
        <ModalHeader>
          {this.state.question ? this.state.question : "Are you sure?"}
        </ModalHeader>
        <ModalBody>{this.state.questionBody}</ModalBody>
        <ModalFooter>
          <Button color="primary" onClick={this.handleConfirm}>
            Ok
          </Button>{" "}
          <Button color="secondary" onClick={this.handleCancel}>
            Cancel
          </Button>
        </ModalFooter>
      </Modal>
    );
  }
}
