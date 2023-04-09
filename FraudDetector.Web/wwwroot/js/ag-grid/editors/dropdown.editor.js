class AgGridDropDownEditor {
    init(params) {
        var colDef = params.colDef;

        this.displayText = colDef.displayText || true;
        this.value = params.value;
        this.input = document.createElement('select');
        this.input.className = 'form-select';
        this.input.style = `min-width: ${params.eGridCell.clientWidth}px`;

        var selectedIndex = -1;
        colDef.options?.forEach((x, i) => {
            var value = this.displayText ? x.text : x.value;
            if (this.value == value)
                selectedIndex = i;
            this.input.options.add(new Option(x.text, x.value));
        });

        this.input.selectedIndex = selectedIndex;

        $(this.input).on('change', (event) => {
            this.value = this.displayText ? event.target.selectedOptions[0].text : event.target.value;
            colDef.onchange != null && colDef.onchange(params.node, event.target.value);
            params.stopEditing();
        });
    }

    /* Component Editor Lifecycle methods */
    // gets called once when grid ready to insert the element
    getGui() {
        return this.input;
    }

    isPopup() {
        return true;
    }

    // the final value to send to the grid, on completion of editing
    getValue() {
        return this.value;
    }

    // Gets called once before editing starts, to give editor a chance to
    // cancel the editing before it even starts.
    isCancelBeforeStart() {
        return false;
    }

    // Gets called once when editing is finished (eg if Enter is pressed).
    // If you return true, then the result of the edit will be ignored.
    isCancelAfterEnd() {
        return false;
    }

    // after this component has been created and inserted into the grid
    afterGuiAttached() {
        $(this.input).select2();
        this.input.focus();
    }

    destroy() {
        $(this.input).select2('close');
        //if ($(this.input).data('select2') != null)
        //    $(this.input).select2('destroy');
    }
}