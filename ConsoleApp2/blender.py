import bpy

def swap_vertex_colors(obj):
    if obj.type != 'MESH':
        return

    mesh = obj.data
    if not mesh.vertex_colors:
        print("No vertex colors found.")
        return

    color_layer = mesh.vertex_colors.active
    if color_layer is None:
        print("No active vertex color layer.")
        return

    for poly in mesh.polygons:
        for idx in poly.loop_indices:
            loop = mesh.loops[idx]
            color = color_layer.data[loop.index].color
            
            r, g, b, a = color
            new_color = (g, b, a, r)
            color_layer.data[loop.index].color = new_color

    print("Vertex color channels swapped.")

active_obj = bpy.context.active_object

swap_vertex_colors(active_obj)