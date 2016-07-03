﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using LCore.Extensions;
using LCore.Interfaces;

// ReSharper disable UnusedParameter.Global

// ReSharper disable UnusedMember.Global

namespace Singularity.Extensions
    {
    [ExtensionProvider]
    public static class GlyphIconExt
        {
        #region Extensions +

        #region Glyph

        public static MvcHtmlString Glyph(this HtmlHelper Html, Icon icon)
            {
            return new MvcHtmlString($"<span class=\"glyphicon glyphicon-{StyleName(icon)}\"></span>");
            }

        #endregion

        #endregion
        
        #region Static Methods +

        #region StyleName

        public static string StyleName(Icon i)
            {
            return i.ToString().ToLower().ReplaceAll("_", "-");
            }

        #endregion

        #endregion
        
        public enum Icon
            {
            adjust,
            alert,
            align_center,
            align_justify,
            align_left,
            align_right,
            apple,
            arrow_down,
            arrow_left,
            arrow_right,
            arrow_up,
            asterisk,
            baby_formula,
            backward,
            ban_circle,
            barcode,
            bed,
            bell,
            bishop,
            bitcoin,
            blackboard,
            bold,
            book,
            bookmark,
            briefcase,
            bullhorn,
            calendar,
            camera,
            cd,
            certificate,
            check,
            chevron_down,
            chevron_left,
            chevron_right,
            chevron_up,
            circle_arrow_down,
            circle_arrow_left,
            circle_arrow_right,
            circle_arrow_up,
            cloud,
            cloud_download,
            cloud_upload,
            cog,
            collapse_down,
            collapse_up,
            comment,
            compressed,
            console,
            copy,
            copyright_mark,
            credit_card,
            cutlery,
            dashboard,
            download,
            download_alt,
            duplicate,
            earphone,
            edit,
            education,
            eject,
            envelope,
            equalizer,
            erase,
            eur,
            euro,
            exclamation_sign,
            expand,
            export,
            eye_close,
            eye_open,
            facetime_video,
            fast_backward,
            fast_forward,
            file,
            film,
            filter,
            fire,
            flag,
            flash,
            floppy_disk,
            floppy_open,
            floppy_remove,
            floppy_save,
            floppy_saved,
            folder_close,
            folder_open,
            font,
            forward,
            fullscreen,
            gbp,
            gift,
            glass,
            globe,
            grain,
            hand_down,
            hand_left,
            hand_right,
            hand_up,
            hd_video,
            hdd,
            header,
            headphones,
            heart,
            heart_empty,
            home,
            hourglass,
            ice_lolly,
            ice_lolly_tasted,
            import,
            inbox,
            indent_left,
            indent_right,
            info_sign,
            italic,
            king,
            knight,
            lamp,
            leaf,
            level_up,
            link,
            list,
            list_alt,
            Lock,
            log_in,
            log_out,
            magnet,
            map_marker,
            menu_down,
            menu_hamburger,
            menu_left,
            menu_right,
            menu_up,
            minus,
            minus_sign,
            modal_window,
            move,
            music,
            new_window,
            object_align_bottom,
            object_align_horizontal,
            object_align_left,
            object_align_right,
            object_align_top,
            object_align_vertical,
            off,
            oil,
            ok,
            ok_circle,
            ok_sign,
            open,
            open_file,
            option_horizontal,
            option_vertical,
            paperclip,
            paste,
            pause,
            pawn,
            pencil,
            phone,
            phone_alt,
            picture,
            piggy_bank,
            plane,
            play,
            play_circle,
            plus,
            plus_sign,
            print,
            pushpin,
            qrcode,
            queen,
            question_sign,
            random,
            record,
            refresh,
            registration_mark,
            remove,
            remove_circle,
            remove_sign,
            repeat,
            resize_full,
            resize_horizontal,
            resize_small,
            resize_vertical,
            retweet,
            road,
            ruble,
            save,
            save_file,
            saved,
            scale,
            scissors,
            screenshot,
            sd_video,
            search,
            send,
            share,
            share_alt,
            shopping_cart,
            signal,
            sort,
            sort_by_alphabet,
            sort_by_alphabet_alt,
            sort_by_attributes,
            sort_by_attributes_alt,
            sort_by_order,
            sort_by_order_alt,
            sound_5_1,
            sound_6_1,
            sound_7_1,
            sound_dolby,
            sound_stereo,
            star,
            star_empty,
            stats,
            step_backward,
            step_forward,
            stop,
            subscript,
            subtitles,
            sunglasses,
            superscript,
            tag,
            tags,
            tasks,
            tent,
            text_background,
            text_color,
            text_height,
            text_size,
            text_width,
            th,
            th_large,
            th_list,
            thumbs_down,
            thumbs_up,
            time,
            tint,
            tower,
            transfer,
            trash,
            tree_conifer,
            tree_deciduous,
            triangle_bottom,
            triangle_left,
            triangle_right,
            triangle_top,
            Unchecked,
            upload,
            usd,
            user,
            volume_down,
            volume_off,
            volume_up,
            warning_sign,
            wrench,
            yen,
            zoom_in,
            zoom_out
            }
        }
    }