# Inspector and metadata model

The editor metadata schema supports display name, icon, category, tooltip, tag, layer and active/static flags. Inspector models are grouped into collapsible sections with property kind, tooltip, read-only state and string-backed editor values. The intended UI groups are GameObject, Metadata, Transform, Rendering, Physics, Audio, Animation, Scripts and Debug. Each section should remain independently scrollable so large components do not push the whole editor off screen.
